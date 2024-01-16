<script>
  import TextArea from '$lib/components/TextArea.svelte'
  import TextInput from '$lib/components/TextInput.svelte'
  import TranslationSelect from '$lib/components/TranslationSelect.svelte'
  import axios from 'axios'
  import {goto} from '$app/navigation'
  import DatePicker from '$lib/components/DatePicker.svelte'


  const onSubmit = (e) => {
    const form = e.currentTarget

    if (form.reportValidity()) {
      axios
        .post('/Translations/create', new FormData(form))
        .then(() => goto('/translations'))
        .catch(err => console.log(err))
    }
    else {
      for (const input of document.querySelectorAll('.form-control')) {
        const validationClass = `is-${input.checkValidity() ? '' : 'in'}valid`
        input.classList.add(validationClass)
        input.addEventListener('input', () => input.classList.remove(validationClass), {  once: true })
      }
    }
  }

</script>

<section>
  <form method="POST" on:submit|preventDefault={onSubmit} novalidate>
    <div class="col-12 text-end mb-4">
      <input type="submit" value="Uložiť" class="btn btn-primary btn-success"/>
    </div>
    <div class="col-12">
      <TextInput label="Názov" name="Title" required/>
      <DatePicker label="Deadline" name="Deadline"/>
      <TranslationSelect/>
      <TextArea label="Text" name="Text" required/>
    </div>
  </form>
</section>
