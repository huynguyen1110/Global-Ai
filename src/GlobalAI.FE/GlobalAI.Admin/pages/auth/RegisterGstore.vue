<template>
  <div class="container mx-auto px-4 h-full">
    <div class="flex content-center items-center justify-center h-full">
      <div class="w-full lg:w-6/12 px-4">
        <div
          class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0"
        >
          <div class="rounded-t mb-0 px-6 py-6">
            <div class="text-center mb-3">
              <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">
                Đăng ký
              </h6>
            </div>
            <hr class="mt-6 border-b-1 border-slate-300" />
          </div>
          <div class="flex-auto px-4 lg:px-10 py-10 pt-0">
            <Form @submit="onRegister" :validationSchema="validateSchema">
              <div class="relative w-full mb-3 grid grid-cols-2 gap-4">
                <div class="col-span-1">
                  <label
                    class="block uppercase text-slate-600 text-xs font-bold mb-2"
                    htmlFor="grid-password"
                  >
                    Họ
                  </label>
                  <Field
                    name="firstName"
                    type="text"
                    class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                  />
                  <error-message name="firstName" class="text-red-500" />
                </div>

                <div class="col-span-1">
                  <label
                    class="block uppercase text-slate-600 text-xs font-bold mb-2"
                    htmlFor="grid-password"
                  >
                    Tên
                  </label>
                  <Field
                    name="lastName"
                    type="text"
                    class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                  />
                  <error-message name="lastName" class="text-red-500" />
                </div>
              </div>
              <div class="relative w-full mb-3 grid grid-cols-2 gap-4">
                <div class="col-span-1">
                  <label
                    class="block uppercase text-slate-600 text-xs font-bold mb-2"
                    htmlFor="grid-password"
                  >
                    SĐT
                  </label>
                  <Field
                    name="phone"
                    type="number"
                    class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                  />
                  <error-message name="phone" class="text-red-500" />
                </div>

                <div class="col-span-1">
                  <label
                    class="block uppercase text-slate-600 text-xs font-bold mb-2"
                    htmlFor="grid-password"
                  >
                    Email
                  </label>
                  <Field
                    name="email"
                    type="email"
                    class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                  />
                  <error-message name="email" class="text-red-500" />
                </div>
              </div>
              <div class="relative w-full mb-3">
                <label
                  class="block uppercase text-slate-600 text-xs font-bold mb-2"
                  htmlFor="grid-password"
                >
                  Địa chỉ
                </label>
                <Field
                  name="address"
                  type="text"
                  class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                />
                <error-message name="address" class="text-red-500" />
              </div>

              <div class="relative w-full mb-3">
                <label
                  class="block uppercase text-slate-600 text-xs font-bold mb-2"
                  htmlFor="grid-password"
                >
                  Tên đăng nhập
                </label>
                <Field
                  name="username"
                  type="text"
                  class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                />
                <error-message name="userName" class="text-red-500" />
              </div>

              <div class="relative w-full mb-3">
                <label
                  class="block uppercase text-slate-600 text-xs font-bold mb-2"
                  htmlFor="grid-password"
                >
                  Mật khẩu
                </label>
                <Field
                  name="password"
                  type="password"
                  class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                />
                <error-message name="password" class="text-red-500" />
              </div>

              <div class="relative w-full mb-3">
                <label
                  class="block uppercase text-slate-600 text-xs font-bold mb-2"
                  htmlFor="grid-password"
                >
                  Nhập lại mật khẩu
                </label>
                <Field
                  name="confirmPassword"
                  type="password"
                  class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                />
                <error-message name="confirmPassword" class="text-red-500" />
              </div>
              <hr class="mt-6 border-b-1 border-slate-300" />

              <div class="mt-6">
                <label class="inline-flex items-center cursor-pointer">
                  <input
                    id="customCheckLogin"
                    type="checkbox"
                    class="form-checkbox border-0 rounded text-slate-700 ml-1 w-5 h-5 ease-linear transition-all duration-150"
                  />
                  <span class="ml-2 text-sm font-semibold text-slate-600">
                    Đồng ý với các
                    <a href="#" class="text-emerald-500"> điều khoản </a>
                  </span>
                </label>
              </div>
              <div class="text-center mt-6">
                <button
                  class="bg-slate-800 text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                >
                  Đăng ký
                </button>
                <!-- <input type="submit" value="nghia test"> -->
              </div>

              <div class="text-center mt-3">
                <p>
                  Đã có tài khoản bấm
                  <nuxt-link to="/auth/login" class="text-emerald-500 underline"
                    >đăng nhập</nuxt-link
                  >
                </p>
              </div>
            </Form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
// import { registerUser } from "~~/api/api.user";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";

definePageMeta({
  layout: "auth",
});

// const { registerUser } = useApiUser();
const router = useRouter();
const { $toast } = useNuxtApp();
const initValues = {
  username: "",
  password: "",
  confirmPassword: "",
  firstName: "",
  lastMame: "",
  email: "",
  phone: "",
  address: "",
};

const validateSchema = yup.object({
  username: yup.string().required("Tên đăng nhập không được bỏ trống").trim(),
  password: yup
    .string()
    .min(6, "Mật khẩu không được ngắn hơn 6 ký tự")
    .required("Mật khẩu không được bỏ trống")
    .trim(),
  confirmPassword: yup
    .string()
    .required("Phải nhập lại mật khẩu một lần nữa")
    .oneOf([yup.ref("password")], "Mật khẩu không khớp")
    .trim(),
  firstName: yup.string().required("Tên không được bỏ trống").trim(),
  lastName: yup.string().required("Họ không được bỏ trống").trim(),
  email: yup
    .string()
    .required("Email không được bỏ trống")
    .email("Email không đúng định dạng")
    .trim(),
  phone: yup.string().required("Số điện thoại không được bỏ trống").trim(),
  address: yup.string().required("Địa chỉ không được bỏ trống").trim(),
});

const onRegister = (data) => {
  const body = {
    ...data,
    userType: "GSTORE",
  };

  registerUser(body)
    .then((res) => {
      if (res.status === 200 && res.data.code === 200) {
        $toast.success("Đăng ký tài khoản store thành công");
        router.push("/auth/login");
      }
    })
    .catch((err) => {
      const msg =
        err?.response?.data?.message || "Có sự cố xảy ra khi đăng nhập";
      $toast.error(msg);
    });
};
</script>
