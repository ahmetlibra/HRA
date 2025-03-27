import axios from "axios";

const API_URL = "https://jsonplaceholder.typicode.com/users";

export const getKullanicilar = async () => {
  return await axios.get(API_URL);
};

export const ekleKullanici = async (yeniKullanici) => {
  return await axios.post(API_URL, yeniKullanici);
};

export const guncelleKullanici = async (id, kullanici) => {
  return await axios.put(`${API_URL}/${id}`, kullanici);
};

export const silKullanici = async (id) => {
  return await axios.delete(`${API_URL}/${id}`);
};
