<template>
  <div>
    <h1>👤 Yeni Kullanıcı Ekle</h1>
    <input v-model="yeniKullanici.name" placeholder="Adınızı girin" required />
    <input v-model="yeniKullanici.email" placeholder="Email girin" required />
    <button @click="ekle">Ekle</button>
  </div>
</template>

<script>
import { useKullaniciStore } from "../stores/kullaniciStore";

export default {
  setup() {
    const store = useKullaniciStore();
    const yeniKullanici = { name: "", email: "" };

    const ekle = () => {
      store.kullaniciEkle(yeniKullanici);
      yeniKullanici.name = "";
      yeniKullanici.email = "";
    };

    return { yeniKullanici, ekle };
  }
};
</script>
