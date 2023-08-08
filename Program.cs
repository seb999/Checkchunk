using System.Collections.Generic;
using System.Linq;

namespace checkChunk
{
    class Program
    {
        static void Main(string[] args)
        {
            string? myChunk = "";
            while (myChunk != "q")
            {
                Console.WriteLine();
                Console.WriteLine("Enter a chunk string to validate or press Enter to use default one");
                Console.WriteLine("Enter q to quit the program");
                myChunk = Console.ReadLine();

                if (myChunk == "")
                {
                    myChunk = "([{{}}[[[()]]][[]][]][[[]()]<<>>[]][[][][]](<[]>{{}})[{[()]}[{}]<>()](()[{<>{}}]{}<>){[[]]()<{}>}[<}[<(){}<>><>{}[]][(<<()>>[<>]){[]{}}]<(<>()){[]}(<>)><(<><>{})>[(<>[]){<()>{}}{<>}]([<>{}]{()})<{<>}>{})";
                    Console.WriteLine(myChunk);
                }

                //both works 
                //int errorIndex = CheckChunk(myChunk);
                int errorIndex = CheckChunkRecursive(myChunk);

                if (errorIndex >= 0)
                {
                    Console.WriteLine($"Wrong closing charactere at index : {errorIndex}");
                }
                else
                {
                    Console.WriteLine("Good Chunk");
                }
            }
        }

        /// <summary>
        /// Check validity of a chunk by using recursivity
        /// </summary>
        /// <param name="chunk">The chunk string</param>
        /// <returns>Index of the error or -1 if valid</returns>
        private static int CheckChunkRecursive(string? chunk)
        {
            Stack<char> stack = new Stack<char>();
            return CheckChunkRecursive(chunk, stack, 0);
        }

        /// <summary>
        /// Check validity of a chunk by using recursivity
        /// </summary>
        /// <param name="chunk">The chunk string</param>
        /// <param name="stack">The stack used to control chunk validity</param>
        /// <param name="index">The index position</param>
        /// <returns>Index of the error or -1 if valid</returns>
        private static int CheckChunkRecursive(string chunk, Stack<char> stack, int index)
        {
            if (index >= chunk.Length)
            {
                if (stack.Count > 0)
                {
                    return chunk.Length;
                }
                return -1;
            }

            char currentChar = chunk[index];

            if (currentChar == '(' || currentChar == '{' || currentChar == '[' || currentChar == '<')
            {
                stack.Push(currentChar);
            }

            if (currentChar == ')' || currentChar == '}' || currentChar == ']' || currentChar == '>')
            {
                if (stack.Count == 0)
                {
                    return index;
                }

                char previousChar = stack.Pop();
                if (!IsValidChunk(previousChar, currentChar))
                {
                    return index;
                }
            }

            return CheckChunkRecursive(chunk, stack, index + 1);
        }

        /// <summary>
        /// Check validity of a chunk by iterating throw the chunk string
        /// </summary>
        /// <param name="chunk">The chunk string</param>
        /// <returns>Index of the error or -1 if valid</returns>
        private static int CheckChunk(string? chunk)
        {
            if (chunk == null) return -1;
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < chunk.Length; i++)
            {
                char currentChar = chunk[i];

                if (currentChar == '(' || currentChar == '{' || currentChar == '[' || currentChar == '<')
                {
                    stack.Push(currentChar);
                }

                if (currentChar == ')' || currentChar == '}' || currentChar == ']' || currentChar == '>')
                {
                    if (stack.Count == 0)
                    {
                        //THis is not okay, the chunk start with a closing character
                        return i;
                    }

                    char previousChar = stack.Pop();
                    if (!IsValidChunk(previousChar, currentChar))
                    {
                        return i;
                    }
                }
            }

            if (stack.Count > 0)
            {
                //THis is not okay, the first and unic character of the chunk is a closing one
                return chunk.Length;
            }

            //No issue
            return -1;
        }

        #region helper

        static bool IsValidChunk(char previousChar, char currentChar)
        {
            return (previousChar == '[' && currentChar == ']') ||
                   (previousChar == '{' && currentChar == '}') ||
                   (previousChar == '(' && currentChar == ')') ||
                   (previousChar == '<' && currentChar == '>');
        }

        #endregion
    }
}