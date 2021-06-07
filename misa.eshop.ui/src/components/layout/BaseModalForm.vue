<template>
  <div class="dialog" v-show="visible">
    <div class="dialog-modal"></div>

    <slot></slot>
  </div>
</template>

<script>
export default {
    data(){
        return{
            visible: false,
        }
    },
    methods:{
        hide(){
            this.visible = false;
        },
        show(){
            this.visible = true;
        }
    }
}
</script>

<style>
@import "../../styles/dialog.css";
</style>