# API de integração do AWS S3

Web API desenvolvida com ASP.NET Core, integrando o AWS para gerenciamento de buckets e operações com arquivos.

---

## 🚀 Features

- Lista S3 buckets
- Upload de arquivos para S3
- Download de arquivos do S3
- Configuração AWS CLI
- Integração do SDK da AWS para .NET

---

## 🛠 Tecnologias

- ASP.NET Core Web API
- AWS S3
- AWS SDK for .NET
- AWS CLI
- C#

---

# 📦 Instalando AWS CLI

Baixe e instale a AWS CLI a partir do site oficial:

https://docs.aws.amazon.com/pt_br/cli/latest/userguide/getting-started-install.html

Após a instalação, verifique:

```bash
aws --version
```

Example output:

```bash
aws-cli/2.x.x Python/3.x Windows/10 exe/AMD64
```

---

# 🔐 Configurando as credenciais da AWS

Crie um usuário IAM na AWS com permissões para o S3 e gere:

- ID da chave de acesso
- Chave de acesso secreta

Configure a AWS CLI:

```bash
aws configure
```

Preencha os campos:

```bash
AWS Access Key ID [None]: YOUR_ACCESS_KEY
AWS Secret Access Key [None]: YOUR_SECRET_KEY
Default region name [None]: us-east-1
Default output format [None]: json
```

Verifique a configuração:

```bash
aws configure list
```

Você também pode testar o acesso:

```bash
aws s3 ls
```

---

# 📥 Instalando o AWS SDK para .NET

Instale o pacote AWS S3:

```bash
dotnet add package AWSSDK.S3
```

NuGet package:

https://www.nuget.org/packages/AWSSDK.S3/

---

# ▶ Executando o Projeto

Clone o repository:

```bash
git clone https://github.com/your-user/s3manager.api.git
```

Acesse a pasta:

```bash
cd s3manager.api
```

Restaurar pacotes:

```bash
dotnet restore
```

Execute o aplicativo:

```bash
dotnet run
```

---

# 📁 Estrutura de projeto sugerida

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

# ☁ Documentação AWS

Documentação oficial do S3:

https://docs.aws.amazon.com/s3/

AWS SDK for .NET documentation:

https://docs.aws.amazon.com/sdk-for-net/

---

# 👨‍💻 Author

Project created only for learning purposes.