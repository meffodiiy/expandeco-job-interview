<script>
  export let name
  export let required = false
</script>

<div class="form-floating mb-3">
  <input required={required} name={name} type="text" class="form-control" id="floatingInput" placeholder="Názov">
  <label for="floatingInput">Názov</label>
</div>
