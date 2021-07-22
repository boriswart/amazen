
<template>
  <div>
    <ContractCard :contract="contract" />
    <div class="card m-3 p-5">
      <h5 class="text-uppercase">
        Contract Bids
      </h5>
      <!-- <div v-for="b in contractBids" :key="b.id">
        <ContractBid :contract-bid="b" />
      </div> -->
    </div>
  </div>
</template>

<script>
import { computed, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { contractsService } from '../services/ContractsService'
import { AppState } from '../AppState'
export default {
  setup() {
    const route = useRoute()
    watchEffect(() => {
      const id = route.params.id
      if (!id) { return }
      contractsService.getContractById(id)
      contractsService.getContractBids(id)
    })
    return {
      contract: computed(() => AppState.contract),
      contractBids: computed(() => AppState.contractBids)
    }
  }
}
</script>

<style>
</style>
