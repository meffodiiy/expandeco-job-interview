<script>
  import {onMount} from 'svelte'
  import axios from 'axios'
  import TextArea from '$lib/components/TextArea.svelte'
  import Select from '$lib/components/Select.svelte'
  import userStore from '$lib/stores/userStore.js'
  import enums from '$lib/enums'

  export let data
  let translation
  let translators
  $: selectedTranslator = translation && translators?.find(({ value }) => value === translation.assignedToId)

  onMount(() => {
    axios.get(`/Translations/${data.id}`)
      .then((result) => {
        translation = result.data
      })
      .catch(err => console.log(err))

    axios.get(`/Users/Translators`)
      .then((result) => {
        translators = [
          {
            value: "",
            text: 'Nikto'
          },
          ...result.data.map(({ id, name }) => ({ value: id, text: name }))
        ]
      })
      .catch(err => console.log(err))
  })

  const onSubmit = (e) => {
    const form = e.currentTarget

    axios
      .patch('/Translations/update', new FormData(form))
      .catch(err => console.log(err))
  }

  let credentials = $userStore
  let canChangeTranslator = credentials?.user.typeId === enums.userTypes.translationManager
  let canWriteTranslation = credentials?.user.typeId === enums.userTypes.translator
</script>

<section>
  <form method="PATCH" on:submit|preventDefault={onSubmit}>
    {#if canChangeTranslator || canWriteTranslation}
      <div class="col-12 text-end mb-4">
        <input type="submit" value="Uložiť" class="btn btn-primary btn-success"/>
      </div>
    {/if}
    <div class="col-12">
      {#if translation}
        <input type="hidden" name="Id" value="{translation.id}"/>
        <div class="d-flex justify-content-between">
          <h1 class="mr-auto">{translation.title}</h1>
          {#if canChangeTranslator}
            <Select name="AssignedToId" label="Prekladateľ" options={translators} bind:selected={selectedTranslator}/>
          {:else}
            <input type="hidden" name="AssignedToId" value="{translation.assignedToId}"/>
            <div class="d-flex align-items-center text-end">
              <span class="text-secondary">Prekladateľ: <strong>{translation.assignedTo?.name ?? 'Nikto'}</strong></span>
            </div>
          {/if}
        </div>
        <h6 class="text-secondary mb-3">
          {translation.sourceLanguage.title} → {translation.targetLanguage.title}
          {#if translation.deadline}
            • Deadline: {new Date(translation.deadline).toLocaleDateString()}
          {/if}
        </h6>
        <div class="d-flex flex-row gap-3">
          <TextArea label="Zdrojový jazyk" name="" value="{translation.text}" readonly/>
          <TextArea label="Cieľový jazyk" name="TranslatedText" value="{translation.translatedText}" readonly={!canWriteTranslation}/>
        </div>
      {/if}
    </div>
  </form>
</section>
