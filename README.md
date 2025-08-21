# Pisti Kart Oyunu

Bu proje, geleneksel Türk kart oyunu Pisti'nin domain modelini Clean Architecture ve SOLID prensipleri kullanarak uygular.

## 🎯 Kod Kalitesi İyileştirmeleri

### Önceki Durum
- Basit "Hello World" konsol uygulaması
- Domain logic yok
- Kod organizasyonu yetersiz

### İyileştirmeler
- ✅ **Domain-Driven Design (DDD)** yaklaşımı uygulandı
- ✅ **Clean Architecture** prensipleri ile katmanlı yapı
- ✅ **SOLID** prensiplerine uygun tasarım
- ✅ **Kapsamlı XML dokümantasyon** eklendi  
- ✅ **Type Safety** ile nullable reference types kullanımı
- ✅ **Proper Exception Handling** implementasyonu
- ✅ **Value Object Pattern** (Card, Hand sınıfları)
- ✅ **Immutable Records** kullanımı (Card sınıfı)
- ✅ **Defensive Programming** teknikleri

## 🏗️ Proje Yapısı

```
pisti/
├── domain/                    # Domain katmanı
│   ├── Entities/             # İş varlıkları
│   │   ├── Card.cs          # Kart değer nesnesi
│   │   └── Player.cs        # Oyuncu varlığı
│   ├── Enums/               # Numaralandırmalar
│   │   ├── Suit.cs          # Kart renkleri
│   │   └── Rank.cs          # Kart değerleri
│   ├── Services/            # Domain servisleri
│   │   └── Deck.cs          # Deste yönetimi
│   └── ValueObjects/        # Değer nesneleri
│       └── Hand.cs          # El (kart koleksiyonu)
└── pisti/                   # Uygulama katmanı
    └── Program.cs          # Ana program
```

## 🎮 Özellikler

### Domain Model
- **Card**: Immutable kart yapısı, yakalama kuralları ve puan hesaplama
- **Player**: Oyuncu varlığı, el ve yakalanan kartlar yönetimi  
- **Hand**: Kart koleksiyonu yönetimi, güvenli erişim
- **Deck**: Tam deste yönetimi, karıştırma ve dağıtma

### Kod Kalitesi Özellikleri
- **Comprehensive Error Handling**: Tüm edge case'ler için uygun exception'lar
- **Null Safety**: C# 8.0 nullable reference types kullanımı
- **Documentation**: Her public member için XML dokümantasyon
- **Immutability**: Mümkün olduğunda immutable tasarım
- **Encapsulation**: Proper data hiding ve kontrollü erişim

## 🚀 Kullanım

```bash
# Projeyi derle
dotnet build

# Demo uygulamasını çalıştır
dotnet run --project pisti
```

## 📋 Pisti Oyun Kuralları

- **Vale (Jack)**: Her kartı yakalayabilir
- **Aynı Değer**: Masadaki kartla aynı değerdeki kart yakalayabilir
- **Puanlama**:
  - Ace: 1 puan
  - Jack: 1 puan  
  - 2♣ (İkili Sinek): 2 puan
  - 10♦ (Onlu Karo): 3 puan

## 🛠️ Teknolojiler

- **.NET 8.0**: Modern C# özellikleri
- **C# 12**: Latest language features
- **Nullable Reference Types**: Type safety
- **Records**: Immutable value objects
- **Pattern Matching**: Modern C# syntax

## 📊 Kod Metrikleri

- **Toplam Satır**: ~400 LOC (documentation dahil)
- **Sınıf Sayısı**: 6 ana sınıf
- **Dokümantasyon**: %100 XML documentation coverage
- **Null Safety**: Fully nullable-aware
- **Exception Handling**: Comprehensive error scenarios covered