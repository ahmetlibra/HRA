<template>
    <div>
      <h1>👤 Kullanıcı Kayıt</h1>
      <form @submit.prevent="kaydet">
        <input v-model="form.name" placeholder="Adınızı girin" />
        <p v-if="hatalar.name" class="hata">{{ hatalar.name }}</p>
  
        <input v-model="form.email" placeholder="Email girin" />
        <p v-if="hatalar.email" class="hata">{{ hatalar.email }}</p>
  
        <button type="submit">Kaydet</button>
      </form>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        form: {
          name: "",
          email: ""
        },
        hatalar: {}
      };
    },
    methods: {
      kaydet() {
        this.hatalar = {};
  
        if (!this.form.name) {
          this.hatalar.name = "İsim zorunludur!";
        }
        if (!this.form.email) {
          this.hatalar.email = "Email zorunludur!";
        } else if (!this.form.email.includes("@")) {
          this.hatalar.email = "Geçerli bir email giriniz!";
        }
  
        if (Object.keys(this.hatalar).length === 0) {
          alert("Form başarıyla gönderildi!");
        }
      }
    }
  };
  </script>
  
  <style>
  .hata {
    color: red;
    font-size: 14px;
  }
  </style>
  