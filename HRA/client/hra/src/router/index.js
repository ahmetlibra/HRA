
import { createRouter, createWebHistory } from "vue-router";
import Anasayfa from "../views/Anasayfa.vue";
import Hakkimizda from "../views/Hakkimizda.vue";
import UrunDetay from "../views/UrunDetay.vue";
import NotFound from "../views/NotFound.vue";
import Kullanicilar from "@/views/Kullanicilar.vue";
import KullaniciEkle from "@/views/KullaniciEkle.vue";
import KullaniciSil from "@/views/KullaniciSil.vue";
import KullaniciGuncelle from "@/views/KullaniciGuncelle.vue";

const routes = [
  { path: "/", component: Anasayfa },
  { path: "/hakkimizda", component: Hakkimizda },
  { path: "/urun/:id", component: UrunDetay },
  { path: "/:pathMatch(.*)*", component: NotFound },

  { path: "/kullanicilar", component: Kullanicilar},
  { path: "/kullanicilar/add", component: KullaniciEkle}, 
  { path: "/kullanicilar/update", component: KullaniciGuncelle}, 
  { path: "/kullanicilar/delete", component: KullaniciSil}, 
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
