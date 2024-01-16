<script>
  import {onMount} from 'svelte'

  export let name
  export let label
  export let required = false
  export let readonly = false
  export let value = ''

  let textarea

  const updateTextAreaHeight = () => {
    textarea.style.height = 'auto'
    textarea.style.height = `${textarea.scrollHeight}px`
  }

  onMount(() => {
    updateTextAreaHeight()
  })
</script>

<style>
    .textarea {
        min-height: 100px;
        resize: none;
        overflow: hidden;
    }
</style>

<div class="form-floating flex-fill">
  <textarea
    {readonly}
    {required}
    {name}
    on:input={updateTextAreaHeight}
    bind:value
    bind:this={textarea}
    class="form-control textarea"
    placeholder="{label}"
    id="floatingTextarea"
  />
  <label for="floatingTextarea">{label}</label>
</div>
