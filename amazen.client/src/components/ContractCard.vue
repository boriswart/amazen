<template>
  <div class="card m-4 shadow">
    <img :src="contract.img" v-if="contract.img" alt="" class="card-img-top">
    <div class="card-body">
      <h3>
        {{ contract.name }}
      </h3>
      <p>{{ contract.description }}</p>
      <div>
        <!-- <router-link :to="{name: 'Contract', params: {id: contract.id}}">
          Contract details
        </router-link> -->
      </div>
    </div>
    <div class="card-footer text-right">
      <b>{{ contract.creator.name }}</b>
      <img :src="contract.creator.picture" alt="contract creator image" class="rounded-circle elevation-1 mx-2" height="40">
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: {
    contract: { type: Object, required: true }
  },
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style>
</style>
