<template>
  <div>
       <section class="centeredPanel">
    <p>Receipt for purchase {{purchaseId}}</p>
    </section>
  </div>
</template>

<script>
export default {
name:"PurchaseReceipt",
data() {
  return {
    purchaseId:0,
    
  }
},
created() {
  this.purchaseId = this.$route.params.id
  //here we will look up the API to get the purchase with the Id
}
}
</script>

<style>

</style>