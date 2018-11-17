using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    public static class GenerateUtility
    {
        public static void RemoveDuplicationSentence(CaptureCodeGeneratorBase generator, List<Sentence> list, object[] pattern)
        {
            Sentence old = null;
            for (int i = list.Count - 1; 0 <= i; i--)
            {
                Sentence current = list[i];
                if (ReferenceEquals(generator, current.Owner))
                {
                    if (old != null)
                    {
                        if (IsDuplicationSentence(old, current, pattern))
                        {
                            list.RemoveAt(i);
                        }
                    }
                }
                old = current;
            }
        }
        
        private static bool IsDuplicationSentence(Sentence lhs, Sentence rhs, object[] pattern)
        {
            if (lhs.Tokens.Length < pattern.Length ||
                rhs.Tokens.Length < pattern.Length)
            {
                return false;
            }
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == null)
                {
                    continue;
                }
                if (pattern[i] is TokenName && lhs.Tokens[i] is TokenName && rhs.Tokens[i] is TokenName)
                {
                    continue;
                }
                if (!lhs.Tokens[i].Equals(pattern[i]))
                {
                    return false;
                }
                if (!rhs.Tokens[i].Equals(pattern[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static void RemoveDuplicationFunction(CaptureCodeGeneratorBase generator, List<Sentence> list, string function)
        {
            bool findChangeText = false;
            for (int i = list.Count - 1; 0 <= i; i--)
            {
                if (IsDuplicationFunction(generator, list[i], function))
                {
                    if (findChangeText)
                    {
                        list.RemoveAt(i);
                    }
                    findChangeText = true;
                }
                else
                {
                    findChangeText = false;
                }
            }
        }

        public static string ToBoolString(bool? isChecked)
            => isChecked == null ? "null" : isChecked.Value.ToString().ToLower();

        private static bool IsDuplicationFunction(CaptureCodeGeneratorBase generator, Sentence sentence, string function)
        {
            if (!ReferenceEquals(generator, sentence.Owner))
            {
                return false;
            }
            if (sentence.Tokens.Length <= 2)
            {
                return false;
            }
            if (!(sentence.Tokens[0] is TokenName) ||
                (sentence.Tokens[1] == null))
            {
                return false;
            }
            return sentence.Tokens[1].ToString().IndexOf("." + function) == 0;
        }

        /// <summary>
        /// テキストを調整する
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <returns>調整済み行。</returns>
        public static string AdjustText(string text)
        {
            text = text.Replace("\"", "\"\"");
            string[] lines = text.Replace("\r\n", "\n").Replace("\r", "\n").Split(new char[] { '\n' });
            StringBuilder builder = new StringBuilder();
            foreach (string line in lines)
            {
                if (0 < builder.Length)
                {
                    builder.Append(" + Environment.NewLine + ");
                }
                builder.Append("@\"" + line + "\"");
            }
            return builder.ToString();
        }

        /// <summary>
        /// 文字列をC#のリテラル文字列に変換します
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToLiteral(string text)
        {
            using (var writer = new StringWriter())
            using (var provider = CodeDomProvider.CreateProvider("CSharp"))
            {
                var expression = new CodePrimitiveExpression(text);
                provider.GenerateCodeFromExpression(expression, writer, options: null);
                return writer.ToString();
            }
        }
    }
}
