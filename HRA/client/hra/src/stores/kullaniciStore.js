import { defineStore } from "pinia";
import axios from "axios";

export const useKullaniciStore = defineStore("kullanici", {
  state: () => ({
    kullanicilar: []
  }),

  actions: {
    async fetchKullanicilar() {
      try {
        const response = await axios.get("https://jsonplaceholder.typicode.com/users");
        this.kullanicilar = response.data;
      } catch (error) {
        console.error("Veri alınırken hata:", error);
      }
    },

    async kullaniciSil(id) {
      try {
        await axios.delete(`https://jsonplaceholder.typicode.com/users/${id}`);
        this.kullanicilar = this.kullanicilar.filter(k => k.id !== id);
      } catch (error) {
        console.error("Silme hatası:", error);
      }
    },
    async kullaniciEkle(yeniKullanici) {
      try {
        const response = await axios.post("https://jsonplaceholder.typicode.com/users", yeniKullanici);
        this.kullanicilar.push(response.data);
      } catch (error) {
        console.error("Kullanıcı eklenemedi:", error);
      }
    }
  }
});
