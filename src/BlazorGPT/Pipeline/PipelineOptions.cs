﻿using System.Text.Json.Serialization;
 

namespace BlazorGPT.Pipeline;

public class ModelsProvidersOptions
{
    public OpenAIModelsOptions OpenAI { get; set; } = new OpenAIModelsOptions();
    public AzureOpenAIModelsOptions AzureOpenAI { get; set; } = new AzureOpenAIModelsOptions();
    public LocalModelsOptions Local { get; set; } = new LocalModelsOptions();

    public OllamaOptions Ollama { get; set; } = new OllamaOptions();

    public ChatModelsProvider GetChatModelsProvider()
    {
        if (OpenAI.IsConfigured())
        {
            return ChatModelsProvider.OpenAI;
        }
        else
        {
            if (AzureOpenAI.IsConfigured())
            {
                return ChatModelsProvider.AzureOpenAI;
            }
            if (Local.IsConfigured())
            {
                return ChatModelsProvider.Local;
            }
        }

        return ChatModelsProvider.Local; 
    }

    public string GetChatModel()
    {

        if (OpenAI.IsConfigured())
        {
            return OpenAI.ChatModel;
        }
        else
        {
            if (AzureOpenAI.IsConfigured())
            {
                return AzureOpenAI.ChatModel;
            }

            if (Local.IsConfigured())
            {
                return Local.LocalModelName;
            }
        }

        return string.Empty;
    }
}


public class OllamaOptions
{
	public string BaseUrl { get; set; } = "";
    public string[] Models { get; set; } = Array.Empty<string>();
    public string ChatModel { get; set; }

    public string[] EmbeddingsModels { get; set; } = Array.Empty<string>();
    public string EmbeddingsModel { get; set; }

    public bool IsConfigured()
    {
        return !string.IsNullOrEmpty(BaseUrl);
    }
}
public class LocalModelsOptions
{
    public string LocalModelName { get; set; } = string.Empty;

    public string ChatModel { get; set; } = string.Empty;
    public string[] ChatModels { get; set; } = Array.Empty<string>();

    public string EmbeddingsModel { get; set; } = string.Empty;
    public string[] EmbeddingsModels { get; set; } = Array.Empty<string>();

    public bool IsConfigured()
    {
        return string.IsNullOrEmpty(LocalModelName);
    }
}

public enum ChatModelsProvider
{
    OpenAI,
    AzureOpenAI,
    Ollama,
    Local
}

public enum EmbeddingsModelProvider
{
    OpenAI,
    AzureOpenAI,
    Ollama,
    Local
}


public class OpenAIModelsOptions
{
    public string ApiKey { get; set; } = string.Empty;

    public string ChatModel { get; set; } = string.Empty;
    public string[] ChatModels { get; set; } = Array.Empty<string>();

    public string EmbeddingsModel { get; set; } = string.Empty;
    public string[] EmbeddingsModels { get; set; } = Array.Empty<string>();

    public bool IsConfigured()
    {
        return !string.IsNullOrEmpty(ApiKey);
    }
}

public class AzureOpenAIModelsOptions
{
    public string ApiKey { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;

    public string ChatModel { get; set; } = string.Empty;
    public Dictionary<string, string> ChatModels { get; set; } = new Dictionary<string, string>();

    public string EmbeddingsModel { get; set; } = string.Empty;


    // deploymentId, modelId
    public Dictionary<string,string> EmbeddingsModels { get; set; } = new Dictionary<string,string>();

    public bool IsConfigured()
    {
        return !string.IsNullOrEmpty(ApiKey);
    }
}

public class PipelineOptions
{
    public ModelsProvidersOptions Providers { get; set; } =  new ModelsProvidersOptions();

    public int MaxTokens { get; set; }

    public string[]? EnabledInterceptors { get; set; }
    public string[]? PreSelectedInterceptors { get; set; }

    public string KrokiHost { get; set; }
    public string StateFileSaveInterceptorPath { get; set; }

    public EmbeddingsSettings Embeddings { get; set; } = new EmbeddingsSettings();

    public string BING_API_KEY { get; set; }
    public string GOOGLE_API_KEY { get; set; }
    public string GOOGLE_SEARCH_ENGINE_ID { get; set; }

    public FileUpload FileUpload { get; set; } = new FileUpload();

    public Bot Bot { get; set; } = new Bot();

}

public class Bot
{
    public string BotSystemInstruction { get; set; }
    public string BotUserId { get; set; }
    public FileUpload FileUpload { get; set; } = new FileUpload();

}
public class EmbeddingsSettings
{
    public string RedisConfigurationString { get; set; }
    public string RedisIndexName { get; set; }
    public int MaxTokensToIncludeAsContext { get; set; }
    public bool UseRedis { get; set; }
    public bool UseSqlite { get; set; }
    public string SqliteConnectionString { get; set; }
}

public class FileUpload
{
    public bool Enabled { get; set; }
}