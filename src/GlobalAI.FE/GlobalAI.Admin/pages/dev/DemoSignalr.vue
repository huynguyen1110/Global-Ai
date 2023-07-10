<template>
    <h1>TEST SIGNALR</h1>
</template>

<script setup>
import * as signalR from '@microsoft/signalr';

onMounted(() => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5003/chatHub")
        .build();

    connection.on("SendMessage", data => {
        console.log(data);
    });

    connection.start()
        .then(() => connection.invoke("SendMessage", "Hello i'm fe", "hehehe"));
})

</script>
