<template>
  <div>
    <h1>{{ mesaj }}</h1>
    <button @click="gonder">Mesaj Gönder</button>
  </div>
</template>

<script>
export default {
  props: ["mesaj"],
  methods: {
    gonder() {
      this.$emit("mesaj-gonder", "Merhaba, üst bileşenden geldim!");
    }
  }
};
</script>
