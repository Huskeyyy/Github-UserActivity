
# Github-UserActivity

A simple command-line application that fetches and displays the recent GitHub events for a user. The application makes use of the [GitHub API](https://docs.github.com/en/rest/reference/activity#list-events-for-a-user) to retrieve user events and display them in a readable format and is a sample project for [roadmap.sh](https://roadmap.sh/projects/github-user-activity)

## Features

- Prompts the user for a GitHub username.
- Fetches recent GitHub events for the specified user.
- Displays the event type, repo name, and creation date.

## Requirements

- GitHub Personal Access Token (PAT) with the required permissions.

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Huskeyyy/Github-UserActivity.git
   cd github-useractivity
   ```



2.  **Set up your GitHub Personal Access Token (PAT)**:
    
    -   **Generate a Personal Access Token**:
        
        -   Visit [GitHubs Personal Access Token page](https://docs.github.com/en/github/authenticating-to-github/creating-a-personal-access-token) to generate your token.
        -   Ensure your token has the `repo` and `read:user` permissions.
    -   **Set the token as an environment variable**:
        
        -   The token is required for authentication when making requests to the GitHub API. You can set it as an environment variable.
        
        **For Windows (PowerShell)**:
        
        ```powershell
        $env:GITHUB_TOKEN = "your_token_here"
        
        ```
        
        **For Windows (Command Prompt)**:
        
        ```cmd
        set GITHUB_TOKEN=your_token_here
        
        ```
        
        **For macOS/Linux**:
        
        ```bash
        export GITHUB_TOKEN="your_token_here"
        
        ```
        
        -   If you want to make the environment variable permanent, you can add the export command to your `~/.bashrc`, `~/.bash_profile`, or `~/.zshrc` file (depending on your shell).
3.  **Build and run the project**: After setting up the environment variable, run the application using the following command in your terminal:
    
    ```bash
    dotnet run
    
    ```
    
4.  **Enter the GitHub username**: The program will prompt you to enter a GitHub username. It will then fetch and display the recent events for that user.

## License

This project is licensed under the MIT License - please see the LICENSE file for details.

## Contributing

If you would like to contribute to this project, please fork the repository and submit a pull request with your changes.

---


