# 📦 Entity Şema Yapısı

## 📁 Genel Yapı

Her **Entity** (varlık) için bir klasör oluşturulmalıdır. Bu klasör içerisinde o entity'ye ait tüm dosyalar yer almalıdır.

### ✅ Yapı Kuralları

- Her entity kendi adını taşıyan bir klasörde bulunmalıdır.
- Klasör içinde entity ile ilişkili tüm sınıflar yer almalıdır (örneğin `Profile`, `Detail` gibi).
- Projeye yeni bir entity eklendiğinde, bu entity `RepositoryContext` sınıfına da eklenmelidir.

---

## 🗂 Örnek Klasör Yapısı

* User 
  * User
  * Profile
* Product
  * Product
  * ProductDetail

Bu yapı, entity’lerin mantıksal gruplar halinde düzenlenmesini sağlar. Her entity kendi bağımsız alanında tanımlı olur.

---

## 🏗 RepositoryContext'e Entity Ekleme

Yeni oluşturulan her entity için `RepositoryContext` sınıfına bir `DbSet` tanımı eklenmelidir.

### 📄 Dosya Yolu:
    Repository/Config/Context/RepositoryContext.cs 



### 📌 Örnek Kullanım:

Aşağıdaki gibi tanımlamalar yapılmalıdır:

```csharp
public DbSet<Entities.User.User> User { get; set; }
public DbSet<Entities.User.Profile> Profile { get; set; }
public DbSet<Entities.User.Detail> Detail { get; set; }

public DbSet<Entities.Product.Product> Product { get; set; }
