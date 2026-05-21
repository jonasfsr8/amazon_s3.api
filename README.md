# AWS S3 Integration API

Web API built with ASP.NET Core integrating AWS S3 for bucket management and file operations.

---

## 🚀 Features

- List S3 buckets
- Upload files to S3
- Download files from S3
- Delete files from S3
- AWS CLI configuration
- AWS SDK integration for .NET

---

## 🛠 Technologies

- ASP.NET Core Web API
- AWS S3
- AWS SDK for .NET
- AWS CLI
- C#

---

# 📦 Installing AWS CLI

Download and install AWS CLI from the official website:

https://docs.aws.amazon.com/pt_br/cli/latest/userguide/getting-started-install.html

After installation, verify:

```bash
aws --version
```

Example output:

```bash
aws-cli/2.x.x Python/3.x Windows/10 exe/AMD64
```

---

# 🔐 Configuring AWS Credentials

Create an IAM user in AWS with S3 permissions and generate:

- Access Key ID
- Secret Access Key

Configure AWS CLI:

```bash
aws configure
```

Fill the fields:

```bash
AWS Access Key ID [None]: YOUR_ACCESS_KEY
AWS Secret Access Key [None]: YOUR_SECRET_KEY
Default region name [None]: us-east-1
Default output format [None]: json
```

Verify configuration:

```bash
aws configure list
```

You can also test access:

```bash
aws s3 ls
```

---

# 📥 Installing AWS SDK for .NET

Install the AWS S3 package:

```bash
dotnet add package AWSSDK.S3
```

NuGet package:

https://www.nuget.org/packages/AWSSDK.S3/

---

# ▶ Running the Project

Clone the repository:

```bash
git clone https://github.com/your-user/s3manager.api.git
```

Access the folder:

```bash
cd s3manager.api
```

Restore packages:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

---

# 📁 Suggested Project Structure

```bash
src/
 ├── Controllers/
 ├── Services/
 ├── Interfaces/
 ├── Models/
 ├── Configurations/
 ├── Middleware/
 └── Program.cs
```

---

# 🔒 Security Notes

Never commit:

- `appsettings.json`
- AWS credentials
- Secret keys

Example `.gitignore`:

```gitignore
appsettings.json
.env
bin/
obj/
```

---

# ☁ AWS Documentation

Official S3 documentation:

https://docs.aws.amazon.com/s3/

AWS SDK for .NET documentation:

https://docs.aws.amazon.com/sdk-for-net/

---

# 👨‍💻 Author

Project created for learning purposes using AWS S3 with ASP.NET Core Web API.