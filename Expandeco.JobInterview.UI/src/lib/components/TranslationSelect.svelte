<script>
  import Select from '$lib/components/Select.svelte'
  import {onMount} from 'svelte'
  import axios from 'axios'

  let options = []
  let fromLanguage
  let toLanguage

  $: if (fromLanguage?.value === toLanguage?.value) swapLanguages()
  $: oldFromLanguage = fromLanguage
  $: oldToLanguage = toLanguage

  onMount(() => {
    axios
      .get("/Languages")
      .then((result) => {
        options = result.data.map(({ id, title }) => ({ value: id, text: title }))
        fromLanguage = options[0]
        toLanguage = options[1]
      })
      .catch((err) => console.log(err));
  });

  const swapLanguages = () => {
    [fromLanguage, toLanguage] = [oldToLanguage, oldFromLanguage]
  }
</script>

<div class="d-flex flex-row justify-content-between mb-3">
  <div class="flex-fill">
    <Select name="SourceLanguageId" label="Zdrojový jazyk" required {options} bind:selected={fromLanguage}/>
  </div>
  <button type="button" on:click={swapLanguages} class="btn mx-3 px-4 pb-2 fs-4 btn-primary">⇄</button>
  <div class="flex-fill">
    <Select name="TargetLanguageId" label="Cieľový jazyk" required {options} bind:selected={toLanguage}/>
  </div>
</div>
