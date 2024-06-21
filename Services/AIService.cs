using StoryWriter.Data.Entities;
using static StoryWriter.Services.OllamaService;

namespace StoryWriter.Services
{
    public class AIService(OllamaService ollamaService)
    {
        private readonly OllamaService _ollamaService = ollamaService;

        public async Task<string?> GetLocationDescription(LocationEntity location)
        {
            var request = new OllamaRequest
            {
                Model = AIConstants.ModelName,
                System = AIConstants.LocationDescriptionSystemPrompt,
                Prompt = PromptGenerator.GenerateLocationDescriptionPrompt(location)
            };
            OllamaResponse? response = await _ollamaService.GetResponseAsync(request);
            return response?.Response;
        }

        public async Task<string?> GetSceneDescription(SceneEntity scene)
        {
            var request = new OllamaRequest
            {
                Model = AIConstants.ModelName,
                System = AIConstants.SceneDescriptionSystemPrompt,
                Prompt = PromptGenerator.GenerateSceneDescriptionPrompt(@scene)
            };
            OllamaResponse? response = await _ollamaService.GetResponseAsync(request);
            return response?.Response;
        }
        public async Task<string?> GetItemDescription(ItemEntity item)
        {
            var request = new OllamaRequest
            {
                Model = AIConstants.ModelName,
                System = AIConstants.ItemDescriptionSystemPrompt,
                Prompt = PromptGenerator.GenerateItemDescriptionPrompt(item)
            };
            OllamaResponse? response = await _ollamaService.GetResponseAsync(request);
            return response?.Response;
        }
        public async Task<string?> GetSceneSuggestions(StoryEntity story)
        {
            var request = new OllamaRequest
            {
                Model = AIConstants.ModelName,
                System = AIConstants.SceneSuggestionSystemPrompt,
                Prompt = PromptGenerator.GenerateSceneSuggestionsPrompt(story)
            };
            OllamaResponse? response = await _ollamaService.GetResponseAsync(request);
            return response?.Response;
        }
        public async Task<string?> GetCharacterDescription(CharacterEntity character)
        {
            var request = new OllamaRequest
            {
                Model = AIConstants.ModelName,
                System = AIConstants.CharacterDescriptionSystemPrompt,
                Prompt = PromptGenerator.GenerateCharacterDescriptionPrompt(character)
            };
            OllamaResponse? response = await _ollamaService.GetResponseAsync(request);
            return response?.Response;
        }
        public async Task<string?> GetStoryDescription(StoryEntity story)
        {
            var request = new OllamaRequest
            {
                Model = AIConstants.ModelName,
                System = AIConstants.StoryDescriptionSystemPrompt,
                Prompt = PromptGenerator.GenerateStoryDescriptionPrompt(story)
            };
            OllamaResponse? response = await _ollamaService.GetResponseAsync(request);
            return response?.Response;
        }
    }
}
