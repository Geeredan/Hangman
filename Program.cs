    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
            Console.ReadLine();
        }

        static void PlayGame()
        {
            // The secret word to guess
            string secretWord = "butterfly";

            // Total attempts allowed
            int maxAttempts = 9;
            int attemptsLeft = maxAttempts;

            // Array to store correctly guessed letters
            char[] guessedWord = new char[secretWord.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            Console.WriteLine("Try to guess secret word!");
            Console.WriteLine($"Amount of letters in word: {secretWord.Length}");
            Console.WriteLine($"Amount of attemps: {maxAttempts}\n");

            bool isWordGuessed = false;

            // Game loop
            while (attemptsLeft > 0 && !isWordGuessed)
            {
                Console.Write("Enter letter: ");
                string input = Console.ReadLine();

                // Validation: ensure the user entered at least one character
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Pleaase enter letter");
                    continue;
                }

                char guessedLetter = input[0]; // Take the first character
                bool isLetterFound = false;
                string positions = "";

                // Check if the guessed letter is in the secret word
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guessedLetter)
                    {
                        guessedWord[i] = guessedLetter; // Reveal the letter
                        isLetterFound = true;
                        positions += (i + 1) + ","; // Save 1-based index for display
                    }
                }

                // Output the result of the turn
                if (isLetterFound)
                {
                    // Remove the trailing comma from positions string
                    positions = positions.TrimEnd(',');
                    Console.WriteLine($"Correct guess! Letter position: {positions}");
                }
                else
                {
                    attemptsLeft--;
                    Console.WriteLine($"Wrong one! Atteps left: {attemptsLeft}");
                }

                // Check if the whole word is guessed
                isWordGuessed = true;
                for (int i = 0; i < guessedWord.Length; i++)
                {
                    if (guessedWord[i] == '_')
                    {
                        isWordGuessed = false;
                        break;
                    }
                }
            }

            // Final output based on the game result
            Console.WriteLine();
            if (isWordGuessed)
            {
                Console.WriteLine($"Congratulations! Secret word was:  {secretWord}.");
            }
            else
            {
                Console.WriteLine($"Sorry but nope. Secret word was: {secretWord}.");
            }
            Console.WriteLine("Thanks for the game!");
        }
    }