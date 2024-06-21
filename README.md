# AI-Integrated Writing Application

## Overview

Welcome to the AI-Integrated Writing Application, a tool designed to enhance your writing experience by combining advanced AI capabilities with robust data management. This application supports various writing styles and document types, ensuring versatility and flexibility for all users.

## Features

1. **AI Autocompletion**:

   - **Intelligent Suggestions**: AI-powered autocompletions for faster writing.
   - **Customizable Suggestions**: Adjust the AI’s creativity level for tailored suggestions.
   - **Context-Aware Recommendations**: Suggestions adapt to the user’s writing style.

2. **Local Data Management**:

   - **Tagging System**: Organize elements with tags for easy retrieval. (In work)
   - **Description Support**: Add detailed descriptions to elements for better context.
   - **Search Functionality**: Quickly find elements using keywords or tags. (In Work)

3. **Text Generation**:
   - **AI-Generated Text**: Create new content with AI-generated text.
   - **Customizable Length**: Generate text of any length for various purposes.

## Planned Features

1. **Local Data Storage**

   - **Encryption**: Data is encrypted using AES-256 for protection.
   - **Password Protection**: Secure access with user-defined passwords.
   - **Secure Communication**: Data transmission is encrypted using TLS.

2. **Advanced AI Capabilities**

   - **Context-Aware Suggestions**: Provides intelligent suggestions for autocompletions and more, adapting to the user’s writing style.
   - **Tagging System**: Users can tag elements to enhance AI suggestions.
   - **Dynamic Context Updates**: AI suggestions stay relevant with updated tags and descriptions.

3. **User-Friendly Interface**
   - **Minimalist Design**: A clean, uncluttered interface to avoid distractions.
   - **Seamless Integration**: AI suggestions appear smoothly as you type.
   - **Creativity Control**: Adjust the AI’s suggestion creativity level.

## Technical Architecture

1. **Front-End**:

   - Built using Blazor

2. **Back-End**:

   - **AI Model**: Generates text based on user input using Ollama AI.
   - Interacts with the local database and the AI model.

3. **Database Integration**:
   - **Vector Database**: Stores embeddings for fast similarity searches. (In Work)
   - **Relational Database**: Stores detailed tags and descriptions. (In Work)

## Acknowledgments

We acknowledge the following libraries and frameworks that contributed to this application:

- **[Bootstrap](https://getbootstrap.com/)**: For creating a responsive front-end framework.
- **[FontAwesome](https://fontawesome.com/)**: For a comprehensive library of icons.
- **[Tabulator](http://tabulator.info/)**: For powerful and interactive table functionalities.
- **[Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)**: For building interactive web UIs using C#.
- **[Ollama AI](https://ollama.com/)**: For providing advanced AI capabilities for text generation.
