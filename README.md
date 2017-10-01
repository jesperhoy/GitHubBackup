# GitHub Backup for Windows

A tool to automatically create and update backups of all repositories under your GitHub account onto a Windows computer.

This tool can be scheduled to run using the Windows Task Scheduler (for example once a day).

It can send you a status notification via e-mail for each run (optionally only for failures).

It can optionally create a log file to disk for each run.

Backups are real mirror / bare repositories. This means that they have no working directory,
but if needed, you can make a clone (with a working directory) directly from a backup repository
by specifying the backup repository directory as the source path.

You can filter which repositories to backup by privacy (public/private), affiliation (owner, contributor, organization-member), 
locked or not, fork or not. 

### Why this tool exists

My source code is one of my most valuable assets (think only of the hours of labor behind it).

I trust that GitHub will do their best to keep it safe, but I simply cannot afford to rely on this alone.
What if GitHub is hacked, what if they go down for an extended prior, what if my own Internet connection goes down
for an extended period... I need to have an automatic and reliable backup system.

You might argue that my local repositories are already full backups of those on GitHub.
The problem with this is that I have around 45 repositories that I work on at different times on different computers in different physical locations.
I cannot manually keep track of what is updated where.
That is why I use GitHub - as my central repository of repositories - that's where all my latest bits are.

Of course other very similar tools / scripts already exists - but mostly for Python and "Bash"(?).
I use Windows, and I don't know Python or Bash. So for me, a Windows tool makes more sense.

### How it works

When run, the tool first fetches a list of your GitHub repositories (using the GitHub GraphQL API). 
Then it makes a local mirror clone of each of these. If a local mirror clone already exists (from prior runs),
it updates this with the latest changes from GitHub.

The tool consists of two Windows executable files "GitHubBackup.exe" and "GitHubBackupCfg.exe":

- "GitHubBackup.exe" is a command line tool which does the actual backup operations as described above.
- "GitHubBackupCfg.exe" is a Windows GUI program used to create a configuration file: ![screenshot](https://user-images.githubusercontent.com/12099212/31050378-fe9ade00-a648-11e7-94be-fdcbbca8ff8c.png)

Backup repositories are stored in the "repositories" directory below the directory where "GitHubBackup.exe" is located.

The backup repositories are named "&lt;GitHubLogin&gt;_&lt;RepositoryName&gt;.git".

Logs are stored in the "logs" directory below the directory where "GitHubBackup.exe" is located.

### Setup

First make sure that "Git for Windows" ( https://git-scm.com/download/win ) and .NET Framework 4.6 are installed / enabled
on the computer.

Next create a directory that will be the root of the backups and download ( https://github.com/jesperhoy/GitHubBackup/releases/latest )
and unzip the tool .exe files there.

Run "GitHubBackupCfg.exe" to make a configuration file. This generates a "config.json" file stored in the same directory as the .exe files. 

Run "GitHubBackup.exe" to make the initial backup and make sure everything is working correctly.

Use Windows Task Scheduler to schedule running "GitHubBackup.exe" on a regular basis.

### License

This project is licensed under the MIT License - see the LICENSE.md file for details.
