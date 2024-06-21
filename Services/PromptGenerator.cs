using StoryWriter.Data.Entities;

namespace StoryWriter.Services
{
    public static class PromptGenerator
    {
        public static string GenerateLocationDescriptionPrompt(LocationEntity location)
        {
            return $@"
The following is a description for a location named '{location.Name}'.
This is a synopsis of the story the location is in:
{location.Story.Description}

Your response should only include the description of the location, no explanation or summary.
Do not include any additional information that is not related to the location description.

Only provide a short description of the location, not the entire location's story.

Update and improve this location description:
{location.Description}
        ";
        }
        public static string GenerateCharacterDescriptionPrompt(CharacterEntity character)
        {
            return $@"
The following is a description for a character named '{character.Name}'.
This is a synopsis of the story the character is in:
{character.Story.Description}

Your response should only include the description of the character, no explanation or summary.
Do not include any additional information that is not related to the character description.

Only provide a short description of the character, not the entire character's story.

Update and improve this character description:
{character.Description}
            ";
        }

        public static string GenerateSceneDescriptionPrompt(SceneEntity @scene)
        {
            return $@"
The following is a description for an scene titled '{@scene.Title}'.
Scene details: 
{@scene.Description}

Your response should only include the description of the scene, no explanation or summary.
Do not include any additional information that is not related to the scene description.

Only provide a short description of the scene, not the entire scene's details.

Update and improve this scene description:
{@scene.Description}
            ";
        }

        public static string GenerateItemDescriptionPrompt(ItemEntity item)
        {
            return $@"
The following is a description for an item named '{item.Name}'.
Item details:
{item.Description}

Your response should only include the description of the item, no explanation or summary.
Do not include any additional information that is not related to the item description.

Only provide a short description of the item, not the entire item's details.

Update and improve this item description:
{item.Description}
            ";
        }

        public static string GenerateSceneSuggestionsPrompt(StoryEntity story)
        {
            return $@"
The following is a synopsis for a story titled '{story.Title}'.
Story synopsis:
{story.Description}

Your response should include three scene suggestions for the story.
Each scene should be engaging and interesting, and fit well within the story's context.

Provide only the scene suggestions, no explanations or summaries.
            ";
        }

        public static string GenerateStoryDescriptionPrompt(StoryEntity story)
        {
            return $@"
The following is a description for a story titled '{story.Title}'.
The story's genre is '{story.Genre}'.

Your response should only include the description of the story, no explanation or summary.
Do not include any additional information that is not related to the story description.

Only provide a short description of the story, not the entire story.

Update and improve this story description:
{story.Description}
            ";
        }
    }
}
