class PromptGenerator
{
    /// <summary>
    /// static List<string> GetPromptQuestion() Return the question list
    /// </summary>
    /// <returns></returns>
    public static List<string> GetPromptQuestion()
    {
        List<string> questions = new List<string>()
        {
            "What is your favorite TV show?",
            "Do you prefer watching TV shows or movies?",
            "Do you like watching the Oscars?",
            "What was the last book you read?",
            "Who is your favorite female singer?",
            "Who is your favorite male singer?",
            "What kind of music do you like?",
        };

        return questions;
    }
}