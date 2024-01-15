<script>
	import TranslationsTable from "$lib/TranslationsTable.svelte";
	import axios from "axios";
	import userStore from "$lib/stores/userStore.js";
	import { onMount } from "svelte";
	import { goto } from "$app/navigation";
	import enums from "$lib/enums";

	let translations = [];
	let credentials = $userStore;

	onMount(() => {
		if (!credentials) goto("/");
		axios
			.get("translations")
			.then((result) => {
				translations = result.data;
			})
			.catch((err) => console.log(err));
	});
</script>

<svelte:head>
	<title>Home</title>
	<meta name="description" content="Svelte demo app" />
</svelte:head>

<section>
	<div class="row">
		{#if credentials && credentials.user.typeId === enums.userTypes.client}
			<div class="col-12 text-end">
				<a href="/translations/create" class="btn btn-primary">Vytvoriť</a>
			</div>
		{/if}
		<div class="col-12">
			<TranslationsTable data={translations} />
		</div>
	</div>
</section>
