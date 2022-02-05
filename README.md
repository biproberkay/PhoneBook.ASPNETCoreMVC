## Yazılımın Hikayesi 
Bu uyg.nın kullanım senaryosu şudur: A şirketinin, şirket içinde veya şirket dışında bağlantılı olduğu özel ve tüzel kişiler vardır. A şirketi bağlantıları ile iletişimini sürdürmek için dijital bir telefon rehberine ihtiyacı olduğuna karar vermiştir. Bunun için yazılım departmanına başvurmuştur. yazılım görevini alan geliştirici olarak görevimiz aşağıdaki **ister**leri karşılayan bir aplikasyon üreterek client·a teslim etmektir.
### İster Analizi
- Telefon rehberini kullanacak olan kişi öncelikle uygulamada bir hesap oluşturmalıdır.<sup>[task](#tasks)</sup>
- Dışardan insanlar telefon rehberine ulaşamasınlar.<sup>[kısıt](#contraints)</sup> 
- Hesabını oluşturan kullanıcıya kendi bağlantı kaydını oluşturması için izin verilsin.
    
    Böylelikle kullanıcı, oluşturduğu bağlantı kaydı ile kendisini sisteme tanıtmış olur. 
- 
### kullanım durumları senaryosu
#### senaryodaki aktörler
- kullanıcı (sıradan)
- administrator (yönetici)
- düzenleyici (manager)

Kullanıcının bağlantı bilgisi yöneticiye düşer. yönetici bağlantı bilgisini kontrol eder ve onaylar veya geri gönderir. eğer kullanıcı bir çalışan ise yönetici kullanıcıya bağlantı isteğindeki departman bilgisine göre o departmanın çalışanı için gerekli yetkileri barındıran rollerin atamasını yapar.<sup>[sonraki versiyonlar](#vs)</sup>

||Admin|Manager|User|Guest|
|---|---|-|-|-|
|Contact(tanıdıklar listesi)|
|departman|
|Employee|
|Identity|

# Tasks
## Kazanımlar
- select kullanmayı deneyimledim
- viewmodel de id propertysi tutarak code generator·ü kullanmayı deneyimledim.


# Kazanımlar
- context·ten aldığım entity model class·ının referansına yazılmış data·yı viewmodel class·ına map eden bir method yazdım.
- [validation attributes](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0#built-in-attributes) viewmodel kullanma tekniğimi geliştirdim. bununla ilgili ham notlarım [link](.\developer-diary\validasyon.md)teki markdown dosyasında

