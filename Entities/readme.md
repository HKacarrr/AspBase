# 📦 Entity Şema Yapısı

## 📁 Genel Yapı

Her **Entity** (varlık) için bir klasör oluşturulmalıdır. Bu klasör içerisinde o entity'ye ait tüm dosyalar yer almalıdır. 
Sistem içindeki entity yapıları Models klasörü altında toplanmalıdır

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
```


### ⚙️ DTO Yapıs ile Entegrasyon

Eklenen her entity için bir DTO oluşmalı ve DTO klasörü altında entity içindeki gibi bir dosya-klasör yapısı hazırlanmalı. 
Eklenen her DTO 🗂 AspBase/Utilities/MappingProfile içerisinde map edilmeli. 
NOT : ReverseMap() işlemi tek seferde 2 map işlemini kapsar. Yani;

    CreateMap<ProductDto, Product>(); 
    CreateMap<Product, ProductDto>();

değerlerini yazmak yerine sadece;
  
    CreateMap<ProductDto, Product>().ReverseMap();

yazılabilir. Sadece DTO içeriği ile entity birebir eşleşmiyorsa o zaman kullanılması doğru değildir. 🚨 ÖNERİLMİYOR

ℹ️ DTO yapısında en önemli konulardan biri de role göre serialize etme işlemi. Her rol için bir DTO oluşturulabilir. Servis
içerisinde role göre DTO map işlemi yapılır. 