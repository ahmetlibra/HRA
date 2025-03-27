<template>
  <div>
    <nav>
      <router-link to="/">Anasayfa</router-link> |
      <router-link to="/hakkimizda">Hakkımızda</router-link> |
      <router-link to="/urun/123">Urun detay</router-link>|
      <router-link to="/kullanicilar">Kullanıcılar</router-link>|
      <router-link to="/kullanicilar/add">Kullanıcı Ekle</router-link>|
      <router-link to="/kullanicilar/update">Kullanıcı Güncelle</router-link>|
      <router-link to="/kullanicilar/delete">Kullanıcı Sil</router-link>|

    </nav>
    
    <router-view></router-view>
  </div>
</template>

<style scoped>
nav {
  background: #42b983;
  padding: 10px;
}
nav a {
  color: white;
  text-decoration: none;
  margin: 0 10px;
}
</style>
