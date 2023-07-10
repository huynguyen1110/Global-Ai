import { HubConnectionBuilder } from '@microsoft/signalr'

export default (context, inject) => {
  const connection = new HubConnectionBuilder()
    .withUrl('http://localhost:5003/hub') // Địa chỉ server
    .withAutomaticReconnect()
    .build()

  inject('signalr', connection)
}
