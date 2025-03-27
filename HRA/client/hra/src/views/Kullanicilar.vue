<template>
  <div>
    <h1>📋 Kullanıcı Listesi</h1>
    <p>Toplam Kullanıcı: {{ toplamKullanici }}</p>
    <button @click="fetchKullanicilar">Kullanıcıları Yükle</button>
    <ul>
      <li v-for="kullanici in kullanicilar" :key="kullanici.id">
        {{ kullanici.name }} ({{ kullanici.email }})
      </li>
    </ul>
  </div>
</template>

<script>
import { useKullaniciStore } from "../stores/kullaniciStore";
import { storeToRefs } from "pinia";

export default {
  setup() {
    const store = useKullaniciStore();
    const { kullanicilar, toplamKullaniciSayisi } = storeToRefs(store);
    const { fetchKullanicilar } = store;

    return { kullanicilar, toplamKullanici: toplamKullaniciSayisi, fetchKullanicilar };
  }
};
</script>
