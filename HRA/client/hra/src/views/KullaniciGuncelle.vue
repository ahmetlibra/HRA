<template>
    <div>
      <h1>✏️ Kullanıcı Güncelle</h1>
      <input v-model="kullanici.name" placeholder="Yeni adınızı girin" />
      <input v-model="kullanici.email" placeholder="Yeni email girin" />
      <button @click="guncelle">Güncelle</button>
    </div>
  </template>
  
  <script>
  import axios from "axios";
  
  export default {
    data() {
      return {
        kullanici: {
          id: 1,
          name: "",
          email: ""
        }
      };
    },
    async mounted() {
      try {
        const response = await axios.get(`https://jsonplaceholder.typicode.com/users/${this.kullanici.id}`);
        this.kullanici = response.data;
      } catch (error) {
        console.error("Kullanıcı bilgisi alınamadı:", error);
      }
    },
    methods: {
      async guncelle() {
        try {
          const response = await axios.put(`https://jsonplaceholder.typicode.com/users/${this.kullanici.id}`, this.kullanici);
          console.log("Güncellenen Kullanıcı:", response.data);
          alert("Kullanıcı başarıyla güncellendi!");
        } catch (error) {
          console.error("Güncelleme hatası:", error);
        }
      }
    }
  };
  </script>
  