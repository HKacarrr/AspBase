# 🗃️ Repository Şeması

Bu bölüm, her bir entity için repository katmanının nasıl yapılandırılması gerektiğini tanımlar. Amaç, kodun okunabilirliğini artırmak, katmanlar arasında tutarlılık sağlamak ve tekrar eden işlemleri merkezi olarak yönetmektir.

---

## 📁 Klasör Yapısı

Her bir varlık (entity) için ayrı bir klasör oluşturulmalı. **Repository klasör yapısı, entity klasör yapısıyla birebir aynı olmalıdır.**

### ✅ Örnek Dosya Hiyerarşisi

    * Entities/Product/ProductDetail
    * Repositories/Poruduct/ProductDetailRepository
Bu şekilde entity ile repository mantıksal olarak eşleşir ve yönetimi kolaylaşır.

---

## 🔗 Dependency Injection (DI) Kaydı

Tüm repository sınıfları, Dependency Injection sistemine manuel olarak tanıtılmalıdır.

### 📍 Dosya Yolu

### 🛠 RegisterRepositories Metodu
AspBase/Extensions/ServiceExtensions.cs

```csharp
public static void RegisterRepositories(this IServiceCollection services)
{
    services.AddScoped<ProductRepository, ProductRepository>();
    // Diğer repository kayıtları...
}
```

### 🧱 AbstractRepository Kullanımı
Her repository sınıfı, AbstractRepository<TEntity> sınıfından türemelidir. Bu abstract sınıf, tüm temel işlemleri barındırır.

🔧 Sağlanan Temel Metotlar

| Metot         | Açıklama                                |
| ------------- | --------------------------------------- |
| `FindAll()`   | Tüm kayıtları getirir                   |
| `FindBy()`    | Şarta göre filtreleme yapar             |
| `FindOneBy()` | Tek bir kayıt döner                     |
| `Add()`       | Yeni kayıt ekler                        |
| `Update()`    | Mevcut kaydı günceller                  |
| `Delete()`    | Kaydı siler                             |
| `Save()`      | Unit of Work mantığı ile işlem tamamlar |



