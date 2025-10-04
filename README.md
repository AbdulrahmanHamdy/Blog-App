
# 📝 BlogApp – ASP.NET Core MVC Blogging Platform

This is a full-featured **Blog Application** built with **ASP.NET Core MVC**, showcasing clean architecture, dynamic content management, category filtering, and image uploads.

---

## 🚀 Features

- ✍️ Create, edit, and delete blog posts
- 🗃️ Organize posts by categories
- 📆 Publish date auto-handling
- 🖼️ Upload and display post images (JPG, PNG)
- 🔍 Filter posts by category
- 📋 Admin-friendly interface
- 🌐 Responsive layout with Bootstrap 5

---

## 🧱 Tech Stack

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **C#**
- **SQL Server / LocalDB**
- **Razor Views**
- **Bootstrap 5**
- **LINQ**
- **jQuery**

---

## 📂 Project Structure

```bash
BlogApp/
├── Controllers/       # MVC Controllers (PostController, etc.)
├── Models/            # EF Models (Post, Category)
├── Views/             # Razor Views for Posts and Shared Layout
│   ├── Post/
│   └── Shared/
├── wwwroot/           # Static files (CSS, JS, Images)
│   ├── uploads/       # Uploaded images
│   ├── css/
│   └── js/
├── Data/              # AppDbContext with EF setup
├── appsettings.json   # DB connection string and config
└── Program.cs         # App entry point and service configuration
```

---

## 🛠️ Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/BlogApp.git
cd BlogApp
```

### 2. Open in Visual Studio

- Open `BlogApp.sln` in **Visual Studio 2022+**
- Make sure NuGet packages restore automatically

### 3. Set Up the Database

Open **Package Manager Console** and run:

```powershell
Add-Migration Init
Update-Database
```

Make sure your `appsettings.json` connection string is correct:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=BlogAppDB;Trusted_Connection=True;"
}
```

### 4. Run the App

```bash
Ctrl + F5
```

---

## ✨ Screenshots

> You can add images in the `wwwroot/uploads` folder and reference them here:

| Home Page | Post Form |
|-----------|-----------|
| ![Home](scree![Screenshot 2025-10-03 195912](https://github.com/user-attachments/assets/ecf60f52-fd2c-463e-a9f8-9b2a0b916487)| ![Create Post](https://github.com/user-attachments/assets/b6121362-f4c5-4e46-a513-953065e28f45)
shots/create.png) |

---

## 📦 Models Overview

### Post.cs

```csharp
public class Post {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageName { get; set; }
    public DateTime PublishDate { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
```

### Category.cs

```csharp
public class Category {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Post> Posts { get; set; }
}
```

---

## 📌 Features To-Do

- [ ] Add rich text editor for post content (e.g., TinyMCE)
- [ ] Implement user login and roles (admin vs viewer)
- [ ] Add pagination for posts
- [ ] Add image resizing on upload
- [ ] Deploy on Render or Azure

---

## 🤝 Credits

- Built by **Abdelrahman Hamdy**
- Inspired by clean blog systems and MVC architecture patterns

---

## 📬 Contact

**Abdelrahman Hamdy**  
📧 Email: abdohamdy@gmail.com  
🔗 GitHub: [github.com/AbdulrehmanHamdy](https://github.com/AbdulrahmanHamdy)

---

> *"Code is like humor. When you have to explain it, it’s bad." – Cory House*

