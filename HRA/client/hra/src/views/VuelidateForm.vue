<script>
import useVuelidate from "@vuelidate/core";
import { required, email } from "@vuelidate/validators";
import { reactive, computed } from "vue";
import { useKullaniciStore } from "../stores/kullaniciStore";

export default {
  setup() {
    const store = useKullaniciStore();

    const form = reactive({
      name: "",
      email: ""
    });

    const rules = computed(() => ({
      name: { required },
      email: { required, email }
    }));

    const v$ = useVuelidate(rules, form);

    const kaydet = async () => {
      v$.value.$validate();
      if (!v$.value.$error) {
        await store.kullaniciEkle(form);
        alert("Kullanıcı başarıyla eklendi!");
        form.name = "";
        form.email = "";
        v$.value.$reset();
      }
    };

    return { form, v$, kaydet };
  }
};  
</script>

<template>
    <div>
      <h1>📌 Vuelidate ile Form Doğrulama</h1>
      <form @submit.prevent="kaydet">
        <input v-model="form.name" placeholder="Adınızı girin" />
        <p v-if="v$.name.$error" class="hata">{{ v$.name.$errors[0].$message }}</p>
  
        <input v-model="form.email" placeholder="Email girin" />
        <p v-if="v$.email.$error" class="hata">{{ v$.email.$errors[0].$message }}</p>
  
        <button type="submit">Kaydet</button>
      </form>
    </div>
  </template>
  
  <script>
  import useVuelidate from "@vuelidate/core";
  import { required, email } from "@vuelidate/validators";
  import { reactive, computed } from "vue";
  
  export default {
    setup() {
      const form = reactive({
        name: "",
        email: ""
      });
  
      const rules = computed(() => ({
        name: { required },
        email: { required, email }
      }));
  
      const v$ = useVuelidate(rules, form);
  
      const kaydet = () => {
        v$.value.$validate();
        if (!v$.value.$error) {
          alert("Form başarıyla gönderildi!");
        }
      };
  
      return { form, v$, kaydet };
    }
  };
  </script>
  
  <style>
  .hata {
    color: red;
    font-size: 14px;
  }
  </style>
  