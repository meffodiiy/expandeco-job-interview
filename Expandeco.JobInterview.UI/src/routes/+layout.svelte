<script>
	import axios from "axios";
	import userStore from "$lib/stores/userStore.js";

	import "../app.css";
	import { goto } from "$app/navigation";

	axios.defaults.baseURL = "https://localhost:5001";

	let credentials;
	userStore.subscribe((item) => {
		credentials = item;
		if (item && item.token)
			axios.defaults.headers.common = {
				...axios.defaults.headers.common,
				Authorization: `Bearer ${item.token}`,
			};
	});

	const handleLogout = () => {
		userStore.set(null);
		goto("/");
	};
</script>

<main class="pt-4 container">
	{#if credentials}
		<div class="row pb-4">
			<div class="col-12 text-end">
				<button
					type="button"
					class="btn btn-secondary"
					on:click={handleLogout}>Odhlásiť sa</button
				>
			</div>
		</div>
	{/if}
	<slot />
</main>
