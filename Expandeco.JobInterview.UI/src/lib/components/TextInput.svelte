<script>
  export let name
  export let label
  export let required = false
</script>

<div class="form-floating mb-3">
  <input {required} {name} type="text" class="form-control" id="floatingInput" placeholder="{label}">
  <label for="floatingInput">{label}</label>
</div>
