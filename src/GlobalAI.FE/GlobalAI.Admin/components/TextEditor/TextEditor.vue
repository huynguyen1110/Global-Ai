<template>
  <div class="h-40">
    <ClientOnly>
      <QuillEditor
        toolbar="full"
        contentType="html"
        :content="modelValue"
        :modules="modules"
        @update:content="($event) => onTextChange($event)"
      />
    </ClientOnly>
  </div>
</template>

<script setup>
import { QuillEditor } from "@vueup/vue-quill";
import "@vueup/vue-quill/dist/vue-quill.snow.css";
import htmlEditButton from "quill-html-edit-button";
// import BlotFormatter from 'quill-blot-formatter'
// import { ImageResize } from 'quill-image-resize-module';
import ImageResize from "quill-image-resize-vue";

const { $moduleImageUploader } = useNuxtApp();

const props = defineProps({
  modelValue: {
    type: String,
    default: "",
  },
});

const modules = [
  $moduleImageUploader,
  { name: "htmlEditButton", module: htmlEditButton, options: {} },
  // {
  //     name: 'blotFormatter',
  //     module: BlotFormatter,
  //     options: {/* options */ }
  // }
  {
    name: "imageResize",
    module: ImageResize,
    options: {
      displaySize: true,
    },
  },
];

const emits = defineEmits(["update:modelValue"]);
const onTextChange = ($event) => {
  emits("update:modelValue", $event);
};
</script>
