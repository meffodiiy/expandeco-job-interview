<script>
  export let name
  export let label
  export let required = false
  export let options = []
  export let selected = options[0]

  const onSelect = (e) => {
    selected = options.find(({value}) => String(value) === e.target.value)
  }

</script>

<div class="form-floating flex-fill">
  <select required={required} name={name} on:change={onSelect} class="form-select" aria-label="Floating label select example">
    {#each options as {text, value}, i (value)}
      <option
        selected={selected ? selected.value === value : i === 0}
        value="{value}"
      >
        {text}
      </option>
    {/each}
  </select>
  <label>{label}</label>
</div>
