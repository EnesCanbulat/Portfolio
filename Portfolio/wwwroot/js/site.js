$(document).ready(function () {

    // İletişim Formu Doğrulama
    const iletisimFormu = document.getElementById("iletisimFormu");
    if (iletisimFormu) {
        iletisimFormu.addEventListener("submit", function (olay) {
            const sirketKutusu = document.getElementById("sirket");
            const emailKutusu = document.getElementById("eposta");
            const mesajKutusu = document.getElementById("mesaj");

            const sirket = sirketKutusu ? sirketKutusu.value.trim() : "";
            const email = emailKutusu ? emailKutusu.value.trim() : "";
            const mesaj = mesajKutusu ? mesajKutusu.value.trim() : "";

            // Eğer zorunlu alanlardan biri boş veya e-posta geçersizse formu engelle
            if (sirket === "" || !email.includes("@") || mesaj === "") {
                olay.preventDefault();
                alert("Lütfen şirket adı, geçerli e-posta ve mesaj alanlarını doldurunuz.");
            }
            // Alanlar doğru doldurulduysa engel kalkar, istek C# ve PostgreSQL'e ulaşır!
        });
    }

    // Footer yılı
    const yilElement = document.getElementById("yil");
    if (yilElement) {
        yilElement.textContent = new Date().getFullYear();
    }
});