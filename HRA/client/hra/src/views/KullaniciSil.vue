<template>
    <div>
      <h1>🗑 Kullanıcı Sil</h1>
      <button @click="sil">Kullanıcıyı Sil</button>
    </div>
  </template>
  
  <script>
  import axios from "axios";
  
  export default {
    data() {
      return {
        kullaniciId: 1
      };
    },
    methods: {
      async sil() {
        try {
          await axios.delete(`https://jsonplaceholder.typicode.com/users/${this.kullaniciId}`);
          alert("Kullanıcı başarıyla silindi!");
        } catch (error) {
          console.error("Silme hatası:", error);
        }
      }
    }
  };
  </script>
  