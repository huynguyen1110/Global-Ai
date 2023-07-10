import ImageUploader from 'quill-image-uploader';

export default defineNuxtPlugin((nuxtApp) => {
    nuxtApp.vueApp.component('ImageUploader', ImageUploader);

    const modules = {
        name: 'imageUploader',
        module: ImageUploader,
        options: {
            upload: file => {

                const config = useRuntimeConfig();
                const baseUrl = config.public.apiEndpoint;

                return new Promise((resolve, reject) => {

                    postFile(file, 'posts').then(res => {
                        console.log(res)
                        resolve(`${baseUrl}/${res.data}`);
                    })
                        .catch(err => {
                            reject("Upload failed");
                            console.error("Error:", err)
                        })
                })
            }
        }
    }

    return {
        provide: { moduleImageUploader: modules },
    };

});