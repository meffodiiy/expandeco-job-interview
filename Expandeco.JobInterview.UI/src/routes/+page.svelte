<script>
	import { goto } from "$app/navigation";
	import axios from "axios";
	import userStore from "$lib/stores/userStore.js";
	import { onMount } from "svelte";

	let users = [];
	let selectedUser;

	onMount(() => {
		axios
			.get("users")
			.then((result) => {
				users = result.data;
				if (users.length) selectedUser = users[0].id;
			})
			.catch((err) => console.log(err));
	});

	const handleLogin = () => {
		const user = users.find((x) => x.id === selectedUser);
		if (user) {
			axios.post("users/login?id=" + user.id).then((result) => {
				userStore.set({
					user,
					token: result.data,
				});
				goto("translations");
			});
		}
	};
</script>

<section>
	<div class="row justify-content-center">
		<div class="col-md-3">
			<div class="mb-3">
				<select class="form-select" bind:value={selectedUser}>
					{#each users || [] as item}
						<option value={item.id}
							>{item.name} ({item.type.title})</option
						>
					{/each}
				</select>
			</div>
			<button class="btn btn-primary w-100" on:click={handleLogin}
				>Prihlásiť sa</button
			>
		</div>
	</div>
</section>
