<template>
    <div class="container mx-auto px-4 h-full">
        <div class="flex content-center items-center justify-center h-full">
            <div class="w-full lg:w-4/12 px-4">
                <div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0">
                    <div class="rounded-t mb-0 px-6 py-6">
                        <div class="text-center mb-3">
                            <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">Đăng nhập</h6>
                        </div>
                    </div>
                    <div class="flex-auto px-4 lg:px-10 pt-0">
                        <form>
                            <div class="relative w-full mb-3">
                                <label class="block uppercase text-slate-600 text-xs font-bold mb-2" htmlFor="grid-password"> Tên đăng nhập hoặc Email (*) </label>
                                <input
                                    type="email"
                                    class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                                    placeholder="Email"
                                />
                            </div>

                            <div class="relative w-full mb-3">
                                <label class="block uppercase text-slate-600 text-xs font-bold mb-2" htmlFor="grid-password"> Mật khẩu (*) </label>
                                <input
                                    type="password"
                                    class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                                    placeholder="Password"
                                />
                            </div>

                            <div class="flex flex-row justify-end">
                                <a href="#" class="text-emerald-500 underline"> Quên mật khẩu </a>
                            </div>

                            <div class="text-center mt-6">
                                <button
                                    class="bg-slate-800 text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                                    type="button"
                                    @click="login"
                                >
                                    Đăng nhập
                                </button>
                            </div>
                        </form>
                        <hr class="mt-3 border-b-1 border-slate-300" />
                    </div>

                    <div class="btn-wrapper text-center mb-3">
                        <div class="text-slate-400 text-center my-3 font-bold">
                            <small>hoặc đăng nhập với</small>
                        </div>
                        <button
                            class="bg-white active:bg-slate-50 text-slate-700 font-normal px-4 py-2 rounded outline-none focus:outline-none mr-2 mb-1 uppercase shadow hover:shadow-md inline-flex items-center font-bold text-xs ease-linear transition-all duration-150"
                            type="button"
                        >
                            <img alt="..." class="w-5 mr-1" :src="github" />
                            Github
                        </button>
                        <button
                            class="bg-white active:bg-slate-50 text-slate-700 font-normal px-4 py-2 rounded outline-none focus:outline-none mr-1 mb-1 uppercase shadow hover:shadow-md inline-flex items-center font-bold text-xs ease-linear transition-all duration-150"
                            type="button"
                        >
                            <img alt="..." class="w-5 mr-1" :src="google" />
                            Google
                        </button>
                    </div>
                    <div class="text-center my-3">
                        <p>
                            Chưa có tài khoản bấm
                            <router-link to="/auth/register/gsaler" class="text-emerald-500 underline">đăng ký</router-link>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script setup>
import { useRouter } from 'vue-router'
import github from '../../assets/github.svg'
import google from '../../assets/img/google.svg'

const router = useRouter()

const login = () => {
    router.push('/gsaler/home')
}
</script>
