### 📘 Controller Şeması

#### 📁 Klasör Yapısı

Her bir varlık (entity) alanı için bir klasör oluşturulmalıdır. Bu klasör içerisinde ilgili **controller** yapıları yer almalıdır. Klasör yapısı, route yapısına uygun olacak şekilde iç içe düzenlenmelidir.

**Örnek:**

- **Route:** `api/workspace/product/detail`
- **Controller Path:** `Api/Workspace/Product/Detail`

Bu yapı sayesinde API dizilimi ile dosya dizilimi birebir örtüşür ve okunabilirlik artar.

---

#### 🧩 Abstract Controller Yapısı

Her controller klasörü içerisinde **muhakkak bir abstract (base) controller** sınıfı bulunmalıdır.

Bu abstract controller:

- Ortak işlemleri (örneğin: `authorization`, `role kontrolü`, `logging` vs.) barındırır.
- Diğer controller sınıfları bu sınıftan türetilir.
- Kod tekrarını azaltır ve tutarlı güvenlik sağlar.

**Avantajı:** Her alanın temelinde ortak kurallar çalıştırılır, böylece yapı daha güvenli ve merkezi hale gelir.

---

#### 📥 HTTP Metot Sıralaması (CRUD)

Controller içindeki metodlar daima sabit bir CRUD sıralaması izlemelidir. Bu sıralamanın dışına çıkılmamalıdır.

| İşlem    | HTTP Metodu | Açıklama         |
|----------|-------------|------------------|
| `List`   | `GET`       | Tüm kayıtları getirir |
| `Create` | `POST`      | Yeni kayıt ekler |
| `Read`   | `GET`       | Tekil kayıt getirir |
| `Update` | `PUT`       | Kayıt günceller  |
| `Delete` | `DELETE`    | Kayıt siler      |

> **Not:** Ekstra route değerleri gerekiyorsa, bu tanımlar en alt noktaya eklenmelidir. Örneğin: `api/product/{id}/status`.

---

#### 🧾 DTO Kullanımı

- **Create** ve **Update** işlemleri her zaman **DTO (Data Transfer Object)** üzerinden yapılmalıdır.
- Entity sınıfı doğrudan API katmanında kullanılmamalıdır.
- Bu yaklaşım sayesinde:
    - Gereksiz veri aktarımı engellenir,
    - Validation işlemleri kolaylaşır,
    - Katmanlar arası bağımlılık azaltılır.

---

#### 🧪 Örnek: ProductController Yapısı

```plaintext
Api/
└── Workspace/
    └── Product/
        ├── BaseProductController.cs   --> Abstract controller
        └── ProductController.cs       --> Gerçekleşen işlemler

Route: api/workspace/product
```

#### ℹ️ TRY-CATCH KULLANIMI

Controller içerisinde çok fazla try-catch kullanmamaya çalışmalıyız.
Eğer try-catch kullanırsak global middleware devre dışı kalmış olur.