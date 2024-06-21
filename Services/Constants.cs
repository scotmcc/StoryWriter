namespace StoryWriter.Services
{
        public static class AIConstants
        {
                public const string ModelName = "openchat:7b-v3.5-q4_0";

                public const string LocationDescriptionSystemPrompt = @"
You are an expert location description creator.
You are given a location and you have to create an engaging and interesting description for it.
Use your creativity and imagination to create the best description.
                ";

                public const string CharacterDescriptionSystemPrompt = @"
You are an expert character description creator.
You are given a character and you have to create an engaging and interesting description for it.
Use your creativity and imagination to create the best description.
";

                public const string SceneDescriptionSystemPrompt = @"
You are an expert scene description creator.
You are given an scene and you have to create an engaging and interesting description for it.
Use your creativity and imagination to create the best description.
";

                public const string ItemDescriptionSystemPrompt = @"
You are an expert item description creator.
You are given an item and you have to create an engaging and interesting description for it.
Use your creativity and imagination to create the best description.
";

                public const string SceneSuggestionSystemPrompt = @"
You are an expert scene suggestion creator.
You are given a story and you have to create engaging and interesting scene suggestions for it.
Use your creativity and imagination to create the best scenes.
";

                public const string StoryDescriptionSystemPrompt = @"
You are an expert story description creator.
You are given a story prompt and you have to create an engaging and interesting description for it.
Use your creativity and imagination to create the best description.
";
        }
}
