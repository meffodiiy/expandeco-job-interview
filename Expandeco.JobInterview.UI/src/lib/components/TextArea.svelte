<script>
  export let name
  export let required = false

  const updateTextAreaHeight = (e) => {
    e.target.style.height = 'auto';
    e.target.style.height = `${e.target.scrollHeight}px`;
  }
</script>

<style>
    .textarea {
        min-height: 100px;
        resize: none;
        overflow: hidden;
    }
</style>

<div class="form-floating">
  <textarea required={required} name={name} on:input={updateTextAreaHeight} class="form-control textarea" placeholder="Text" id="floatingTextarea"></textarea>
  <label for="floatingTextarea">Text</label>
</div>
