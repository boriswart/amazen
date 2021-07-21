<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-4 col-md-6" v-for="c in contracts" :key="c.id">
          <ContractCard :contract="c" />
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { contractsService } from '../services/ContractsService'

export default {
  setup() {
    onMounted(() => {
      contractsService.getContracts()
    })
    return reactive({
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      contracts: computed(() => AppState.contracts)
    })
  }

}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
