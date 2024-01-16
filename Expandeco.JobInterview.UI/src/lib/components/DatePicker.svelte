<script>
  export let name
  export let label
  export let required = false
  export let value = undefined

  $: if (value instanceof Date) {
    value = new Intl.DateTimeFormat("fr-CA", {year: "numeric", month: "2-digit", day: "2-digit"}).format(Date.now())
  }

  let datePicker

  const triggerCalendar = () => datePicker.showPicker()
</script>

<div class="form-floating mb-3" on:click={triggerCalendar} on:keydown on:keyup on:keypress>
  <input {name} {label} {required} bind:this={datePicker} bind:value type="date" class="form-control" id="floatingDate">
  <label for="floatingDate">{label}</label>
</div>
