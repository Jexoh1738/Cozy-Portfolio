// ES module — imported via IJSRuntime "import", never attached to window.
// Owns the single <audio> element for the whole app session.

let audioEl = null;
let currentSrc = null;
let mutedState = false;
let targetVolume = 0.2;
let fadeHandle = null;

function ensureAudioElement() {
    if (!audioEl) {
        audioEl = document.createElement('audio');
        audioEl.loop = true;
        audioEl.volume = 0;
        audioEl.muted = mutedState;
        document.body.appendChild(audioEl);
    }
    return audioEl;
}

function clearFade() {
    if (fadeHandle) {
        clearInterval(fadeHandle);
        fadeHandle = null;
    }
}

export function init() {
    ensureAudioElement();
}

export function crossfadeTo(src, durationMs) {
    const el = ensureAudioElement();
    if (currentSrc === src) {
        return;
    }

    clearFade();
    const steps = 20;
    const stepTime = Math.max(1, Math.floor(durationMs / steps / 2));
    let outStep = 0;

    fadeHandle = setInterval(() => {
        outStep++;
        el.volume = Math.max(0, 1 - outStep / steps);

        if (outStep >= steps) {
            clearFade();
            currentSrc = src;
            el.src = src;
            el.currentTime = 0;

            // Swallow rejection deliberately: missing file, autoplay block, or
            // load error should never throw an unhandled promise into Blazor.
            el.play().catch(() => {});

            let inStep = 0;
            fadeHandle = setInterval(() => {
                inStep++;
                el.volume = Math.min(targetVolume, targetVolume * inStep / steps);
                if (inStep >= steps) clearFade();
            }, stepTime);
        }
    }, stepTime);
}

export function setMuted(muted) {
    mutedState = muted;
    ensureAudioElement().muted = muted;
}

export function setVolume(volume) {
    targetVolume = Math.min(0.5, Math.max(0, volume));
    if (audioEl && !audioEl.paused) {
        audioEl.volume = targetVolume;
    }
}

export function dispose() {
    clearFade();
    if (audioEl) {
        audioEl.pause();
        audioEl.src = '';
        audioEl.remove();
        audioEl = null;
    }
    currentSrc = null;
}