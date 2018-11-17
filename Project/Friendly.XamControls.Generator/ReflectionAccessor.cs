using System;
using System.Collections.Generic;
using System.Reflection;

namespace Friendly.XamControls.Generator
{
    public class ReflectionAccessor
    {
        static Dictionary<string, Type> _fullNameAndType = new Dictionary<string, Type>();

        public object Object { get; }

        public ReflectionAccessor(object obj) => Object = obj;

        public T GetProperty<T>(string name)
            => (T)Object.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(Object, new object[0]);

        public void SetProperty(string name, object value)
            => Object.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SetValue(Object, value, new object[0]);

        public T InvokeMethod<T>(string name, params object[] args)
             => (T)Object.GetType().GetMethod(name, BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic).Invoke(Object, args);

        public static object CreateInstance(string typeFullName, params object[] args)
        {
            var type = GetType(typeFullName);
            return Activator.CreateInstance(type, args);
        }

        public static Type GetType(string typeFullName)
        {
            lock (_fullNameAndType)
            {
                //キャッシュを見る
                Type type = null;
                if (_fullNameAndType.TryGetValue(typeFullName, out type))
                {
                    return type;
                }

                //各アセンブリに問い合わせる			
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                List<Type> assemblyTypes = new List<Type>();
                foreach (Assembly assembly in assemblies)
                {
                    type = assembly.GetType(typeFullName);
                    if (type != null) break;
                }
                if (type != null)
                {
                    _fullNameAndType.Add(typeFullName, type);
                }
                return type;
            }
        }

        public static T GetStaticProperty<T>(string typeFullName, string name)
             => (T)GetType(typeFullName).GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null, new object[0]);

        public static T GetStaticField<T>(string typeFullName, string name)
             => (T)GetType(typeFullName).GetField(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);

        public static void SetStaticProperty(string typeFullName, string name, object value)
             => GetType(typeFullName).GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value, new object[0]);

        public static object InvokeStaticMethod(string typeFullName, string method, params object[] args)
            => GetType(typeFullName).GetMethod(method, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Invoke(null, args);
    }
}
